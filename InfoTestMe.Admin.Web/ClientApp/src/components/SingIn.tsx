import * as React from 'react';
import { useState } from 'react';
import requestUrl from '../RequestUrls.json';
import { getToken } from './js/services/CommonRequestService';

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

    const submitSingIn = async event => {
        event.preventDefault();

        let token = await getToken(singIn.email, singIn.password);
        if(token !== null && token !== undefined) window.location.replace(`/mypage`);

    };

    return (
        <div className="form">
            <h2>Авторизация</h2>
            <form onSubmit={submitSingIn}>
            <p>Email:
                    <input type="text" id="email" name="email" value={singIn.email} onChange={changeInputSingIn} />
            </p>
            <p>Password:
                    <input type="password" id="password" name="password" value={singIn.password} onChange={changeInputSingIn} />
                </p>
                <input className='common-btn' type="submit" />
            </form>
        </div>
        );
}