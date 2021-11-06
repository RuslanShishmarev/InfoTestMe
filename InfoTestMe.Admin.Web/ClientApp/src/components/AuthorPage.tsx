import * as React from 'react';
import { connect } from 'react-redux';
import EditAuthor from './EditAuthor';
import requestUrl from '../RequestUrls.json';
import {getAuthor, AuthorBody}  from './js/services/AuthorRequestService';


class AuthorPage extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            profile: {},
            image: "",
            isEditerOpen: false,
         }
        this.loadData = this.loadData.bind(this)
    }

    componentDidMount() {
        this.loadData()
    };

    async loadData() {

        let authorInfo = await getAuthor();
        
        if(authorInfo !== null && authorInfo !== undefined) {
            this.setState({
                profile: authorInfo,
                image: "data:image/jpg;base64," + authorInfo.image
            });
        } else {
            window.location.replace(`/singin`);  
        }

    }

    onClose = () => this.setState({
        isEditerOpen: false,
    })
    openEditModelWnd =() => this.setState({
            isEditerOpen: true,
        });
    

    render() {
        return (
            <div className="author-page" style={{width: "100%", height: "100%"}}>
                <div className="author-data">
                    <ul>
                        {
                            this.state.image.length > 30 ?
                            <li>
                                <img style={{width: '200px'}} 
                                    id="profileImage" src={this.state.image}/>                        
                            </li>
                            :
                            <li></li>
                        }
                        <li>
                            Почта: {this.state.profile.email}
                        </li>
                        <li>
                            Имя: {this.state.profile.firstName}
                        </li>
                        <li>
                            Фамилия: {this.state.profile.lastName}
                        </li>
                        <li>
                            Описание: {this.state.profile.description}
                        </li>
                        <li>
                            Ключевые слова: {this.state.profile.keyWords}
                        </li>
                    </ul>
                </div>
                <button className='common-btn' onClick={this.openEditModelWnd}>Edit</button>
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
                />
            </div>
        );
    };
};

export default AuthorPage;    
