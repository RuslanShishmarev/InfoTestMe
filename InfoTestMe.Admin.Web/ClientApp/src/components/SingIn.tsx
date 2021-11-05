import * as React from 'react';
import { useState } from 'react';

export default function SingIn() {

    const [singIn, setSingIn] = useState(() => {
        return {
            email: "",
            password: "",
        }
    });

    const changeInputSingIn = event => {
        event.persist()
        setSingIn(prev => {
            return {
                ...prev,
                [event.target.name]: event.target.value,
            }
        })
    };

    const submitSingIn = event => {
        event.preventDefault();
        
        let singInLP = Buffer.from(singIn.email + ":" + singIn.password).toString('base64');

        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Basic ' + singInLP.toString()
            },
        };

        let token = "";
        fetch(`api/accounts/token?type=author`, requestOptions)
            .then(
                function (response) {
                    if (response.status !== 200) {
                        alert('Looks like there was a problem. Status Code: ' +
                            response.status);
                        return;
                    }

                    // Examine the text in the response  
                    response.json().then(function (data) {
                        //get token and add to local data
                        token = data.token;
                        sessionStorage.setItem("token", token.toString());

                        //redirect to home page
                        window.location.replace(`/mypage`);
                    });
                }
            )
            .catch(function (err) {
                alert('Auth error');
            });              
    };

    return (
        <div className="form">
            <h2>Регистрация автора:</h2>
            <form onSubmit={submitSingIn}>
            <p>Почта:
                    <input type="text" id="email" name="email" value={singIn.email} onChange={changeInputSingIn} />
            </p>
            <p>Пароль:
                    <input type="password" id="password" name="password" value={singIn.password} onChange={changeInputSingIn} />
                </p>
                <input type="submit" />
            </form>
        </div>
        );
}