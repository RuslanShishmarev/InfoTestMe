import * as React from 'react';
import { connect } from 'react-redux';
import { setState } from 'react';



class AuthorPage extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            profile: {} }
        this.loadData = this.loadData.bind(this)
    }

    componentDidMount() {
        this.loadData()
    };

    loadData() {
        const requestOptions = {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem('token')
            },
        };

        fetch(`api/accounts?type=author`, requestOptions).then(
            response => {
                if (response.status !== 200) {
                    alert('Какая-то проблема. Статус : ' +
                        response.status);
                    return;
                }

                // Examine the text in the response  
                response.json().then(data => {
                    //set properties value
                    this.setState({
                        profile: data
                    });
                });
            }
        ).catch(function (err) {
                alert('Ошибка авторизации');
            }); 

    }

    render() {
        return (
            <div className="author-page">
                <ul>
                    <li>
                        Почта {this.state.profile.email}
                    </li>
                    <li>
                        Имя {this.state.profile.firstName}
                    </li>
                    <li>
                        Фамилия {this.state.profile.lastName}
                    </li>
                </ul>
            </div>
        );
    };
};

export default AuthorPage;    
