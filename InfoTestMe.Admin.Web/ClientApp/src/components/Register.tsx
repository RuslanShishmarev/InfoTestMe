import * as React from 'react';
import { useState } from 'react';
import requestUrl from '../RequestUrls.json';
import {createAuthor, AuthorBody}  from './js/services/AuthorRequestService';

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

    const getFileBytes = (files) => {
        var reader = new FileReader();
        reader.onload = function(){
            let arrayBuffer = this.result as ArrayBuffer;
            let bytes = new Uint8Array(arrayBuffer);
            setRegister(prev => { 
                return {
                    ...prev,
                    image: bytes
                }
            });
          }
          reader.readAsArrayBuffer(files[0]);

          let labelFileName = document.querySelector('#loadImageName') as HTMLUnknownElement;
          let fileName = files[0].name;

          labelFileName.innerText = fileName == null ? "Nothing" : fileName;
      }

    const submitCheckin = event => {
        event.preventDefault();
        if (register.email == "" || register.email.includes("@") == false) {
            alert("Неправильная почта");
        } else if (register.password !== register.password2) {
            alert("Введите одинаковый пароль");
        } else if (register.password.length < 4) {
            alert("Пароль должен содержать больше 4 символов");
        } else {

            const newAuthor: AuthorBody = {
                id: 0,
                firstname: register.firstname,
                lastname: register.lastname,
                email: register.email,
                description: register.description,
                keywords: register.keywords.split(' '),
                image: register.image == null ? null : register.image.toString(),
                password: register.password,                
            }

            createAuthor(newAuthor);
            window.location.replace(`/singin`);
        }
    };

    return (
        <div className="form">
            <h2>Регистрация автора:</h2>
            <form onSubmit={submitCheckin}>
                <p>Имя:</p>
                <input type="text" id="firstname" name="firstname" value={register.firstname} onChange={changeInputRegister} />
                
                <p>Фамилия:</p>
                <input type="text" id="lastname" name="lastname" value={register.lastname} onChange={changeInputRegister} />
                
                <p>Почта:</p>
                <input type="text" id="email" name="email" value={register.email} onChange={changeInputRegister} />
                
                <p>Фото:</p>
                <div className='load-file-btn'>
                    <label>
                        <input type="file" accept="image/*"  id="loadImage" name="image" onChange={(e) => getFileBytes(e.target.files)} />
                            <span id="loadImageName">Выберите файл</span>
                    </label>
                </div>

                <p>Описание:</p>
                <textarea id="description" name="description" value={register.description} onChange={changeInputRegister} />
                
                <p>Ключевые слова (через пробел):</p>
                <textarea id="keywords" name="keywords" value={register.keywords} onChange={changeInputRegister} />
                
                <p>Пароль:</p>
                <input type="password" id="password" name="password" value={register.password} onChange={changeInputRegister}/>
                
                <p>Повторите пароль:</p>
                <input type="password" id="password2" name="password2" value={register.password2} onChange={changeInputRegister} />
                
                <input type="submit" />
            </form>
        </div>
        );

}