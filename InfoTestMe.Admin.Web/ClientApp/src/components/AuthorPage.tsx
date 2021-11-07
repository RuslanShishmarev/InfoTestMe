import * as React from 'react';
import { connect } from 'react-redux';
import EditAuthor from './EditAuthor';
import requestUrl from '../RequestUrls.json';
import {getAuthor}  from './js/services/AuthorRequestService';
import CreateCourse from './course/CreateCourse';
import words from '../LetterMessages.json';
import './css/author-page.css';
import {CourseBodyModel} from './interfaces/ICourse';


class AuthorPage extends React.Component {
    constructor(props: Readonly<{}>) {
        super(props)
        this.state = {
            profile: { },
            image: "",
            keywords: "",
            isEditerOpen: false,
            isNewCourseOpen: false,
            descriptionAsHtml: "",
            courses: []
         }
        this.loadData = this.loadData.bind(this);
        this.updateAuthor = this.updateAuthor.bind(this);
    }

    componentDidMount() {
        this.loadData()
    };

    async loadData() {

        let authorInfo = await getAuthor();
        
        if(authorInfo !== null && authorInfo !== undefined) {

            const coursesAsBtns = (authorInfo.courses as CourseBodyModel[]).map(course => {
                return (
                    <button key={course.id} className='round-btn' title={course.description.slice(0, 100)}>{course.name}</button>
                );
            });

            let descriptionAsHtml = authorInfo.description;
            if((descriptionAsHtml as string).includes('<br>') === true)
                descriptionAsHtml = (authorInfo.description as string).split('<br>').map(strLine => {
                return (
                    <p style={{margin:"5px"}}>{strLine}</p>
                );
            })

            const keywords = (authorInfo.keyWords as string[]).join(' ');

            this.setState({
                profile: authorInfo,
                image: "data:image/jpg;base64," + authorInfo.image,
                keywords: keywords,
                descriptionAsHtml: descriptionAsHtml,
                courses: coursesAsBtns
            });
        } else {
            window.location.replace(`/singin`);  
        }

    }

    onClose = () => this.setState({
        isEditerOpen: false,
    })
    onCloseNewCourse = () => this.setState({
        isNewCourseOpen: false,
    })

    openEditModelWnd =() => this.setState({
            isEditerOpen: true,
        });

    openNewCourse =() => this.setState({
        isNewCourseOpen: true,
        });

    updateAuthor = () => 
    {
        this.loadData()
    }

    render() {
        return (
            <div className="author-page" style={{width: "100%", height: "100%"}}>
                <div className="author-data">
                    <div>{
                            this.state.image.length > 30 ?
                            <img style={{width: '200px'}} 
                                    id="profileImage" src={this.state.image}/>
                            :
                            null
                        }
                    </div>
                    <ul>                        
                        <li>
                            <strong>{words.tags.author.properties.email}:</strong> {this.state.profile.email}
                        </li>
                        <li>
                            <strong>{words.tags.author.properties.firstname}:</strong> {this.state.profile.firstName}
                        </li>
                        <li>
                            <strong>{words.tags.author.properties.lastname}:</strong> {this.state.profile.lastName}
                        </li>
                        <li>
                            <strong>{words.tags.author.properties.description}:</strong>
                            {this.state.descriptionAsHtml}
                        </li>
                        <li>
                            <p><strong>{words.tags.author.properties.keywords}:</strong> {this.state.keywords}</p>
                        </li>
                        <li>
                            <button className='common-btn' onClick={this.openEditModelWnd}>{words.actions.edit}</button>
                         </li>
                    </ul>
                </div>
                <EditAuthor
                    visible = {this.state.isEditerOpen}
                    id={this.state.profile.id}
                    firstname={this.state.profile.firstName}
                    lastname={this.state.profile.lastName}
                    email={this.state.profile.email}
                    description={this.state.profile.description}
                    keywords={this.state.profile.keyWords}
                    image={this.state.profile.image}
                    onClose={this.onClose}
                    reloadAuthor={this.updateAuthor}
                />
                <CreateCourse 
                    visible={this.state.isNewCourseOpen} 
                    name={''} 
                    description={''} 
                    image={null} 
                    onClose={this.onCloseNewCourse}
                    reloadAuthorPage={this.updateAuthor}/>

                <div className="author-products">
                    <div className="courses">
                        <h1>{words.tags.course.listname}</h1>
                        <div className="course-list">
                            <button className='round-btn' onClick={this.openNewCourse}>➕</button>
                            {this.state.courses}
                        </div>
                        
                    </div>
                    <div className="tests">
                        <h1>{words.tags.test.listname}</h1>
                    </div>
                </div>
            </div>
        );
    };
};

export default AuthorPage;    
