import * as React from 'react';
import { useState } from 'react';
import requestUrl from '../RequestUrls.json';
import { getToken } from './js/services/CommonRequestService';
import './css/singin.css';
import words from '../LetterMessages.json';

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
        <div className="singin-form">
            <h2>{words.actions.singin}</h2>
            <form onSubmit={submitSingIn}>
                <p>{words.tags.author.properties.email}:</p>
                <input type="text" id="email" name="email" value={singIn.email} onChange={changeInputSingIn} />                
                <p>{words.tags.author.properties.password}:</p>
                <input type="password" id="password" name="password" value={singIn.password} onChange={changeInputSingIn} />
                <input className='common-btn' type="submit" />
            </form>
        </div>
        );
}