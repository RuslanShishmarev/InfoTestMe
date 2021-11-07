import * as React from 'react';
import { useState } from 'react';
import requestUrl from '../RequestUrls.json';
import './css/create-author-page.css';
import {createAuthor}  from './js/services/AuthorRequestService';
import words from '../LetterMessages.json';
import { selectImageBytesFromFile } from './js/services/UIServices';
import { AuthorBodyModel } from './interfaces/IAuthor';

export default function Register() {

    const [register, setRegister] = useState(() => {
        return {
            firstname: "",
            lastname: "",
            email: "",
            description: "",
            keywords: "",
            image: null,

            password: "",
            password2: "",
        }
    });

    const changeInputRegister = event => {
        event.persist()
        setRegister(prev => {
            return {
                ...prev,
                [event.target.name]: event.target.value,
            }
        })
    };

    const setRegisterImage = (bytes: any) => {
        setRegister(prev => { 
            return {
                ...prev,
                image: bytes
            }
        });
    }

    const getFileBytes = (files) => {
          let labelFileName = document.querySelector('#loadImageName') as HTMLUnknownElement;
          selectImageBytesFromFile(files[0], labelFileName, setRegisterImage);
      }

    const submitCheckin = event => {
        event.preventDefault();
        if (register.email == "" || register.email.includes("@") == false) {
            alert(words.messages.author.errors.nullEmail);
        } else if (register.password !== register.password2) {
            alert(words.messages.author.errors.checkPassword);
        } else if (register.password.length < 4) {
            alert(words.messages.author.errors.shortPassword);
        } else {

            const newAuthor: AuthorBodyModel = {
                id: 0,
                firstname: register.firstname,
                lastname: register.lastname,
                email: register.email,
                description: register.description,
                keywords: register.keywords.split(' '),
                image: register.image == null ? null : register.image.toString(),
                password: register.password,                
            }

            const goToSingIn = () => {
                window.location.replace(`/singin`);
            }
            createAuthor(newAuthor, goToSingIn);
        }
    };

    return (
        <div className="create-author-page">        
            <div className="create-author-form">
                <h2>{words.actions.createAuthor}:</h2>
                <form onSubmit={submitCheckin}>
                    <p>{words.tags.author.properties.firstname}:</p>
                    <input type="text" id="firstname" name="firstname" value={register.firstname} onChange={changeInputRegister} />
                    
                    <p>{words.tags.author.properties.lastname}:</p>
                    <input type="text" id="lastname" name="lastname" value={register.lastname} onChange={changeInputRegister} />
                    
                    <p>{words.tags.author.properties.email}:</p>
                    <input type="text" id="email" name="email" value={register.email} onChange={changeInputRegister} />
                    
                    <p>{words.words.common.image}:</p>
                    <div className='load-file-btn'>
                        <label>
                            <input type="file" accept="image/*"  id="loadImage" name="image" onChange={(e) => getFileBytes(e.target.files)} />
                                <span id="loadImageName">{words.actions.selectFile}</span>
                        </label>
                    </div>

                    <p>{words.tags.author.properties.description}:</p>
                    <textarea id="description" name="description" value={register.description} onChange={changeInputRegister} />
                    
                    <p>{words.tags.author.properties.keywords} {words.tags.author.properties.keywordsAt}:</p>
                    <textarea id="keywords" name="keywords" value={register.keywords} onChange={changeInputRegister} />
                    
                    <p>{words.tags.author.properties.password}:</p>
                    <input type="password" id="password" name="password" value={register.password} onChange={changeInputRegister}/>
                    
                    <p>{words.actions.passwordRepeat}:</p>
                    <input type="password" id="password2" name="password2" value={register.password2} onChange={changeInputRegister} />
                    
                    <input className='common-btn' type="submit"/>
                </form>
            </div>
        </div>
        );

}