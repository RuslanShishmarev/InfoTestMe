import * as React from 'react';
import { useState } from 'react';

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
        //let arrayBytes = reader.readAsArrayBuffer(files[0]);
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
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(
                    {
                        firstname: register.firstname,
                        lastname: register.lastname,
                        email: register.email,
                        description: register.description,
                        keywords: register.keywords.split(' '),
                        image: register.image == null ? null : register.image.toString(),
                        password: register.password,
                    })
            };

            let statusResponse = 200;
            fetch(`api/accounts/author`, requestOptions).then(response => {
                if (response.status == 409) {
                    alert('Author with ' + register.email + ' is already exist');    
                    return;                   
                }   
                window.location.replace(`/singin`);             
            })
            .catch(function (err) {
                alert('Register error');
            });
        }
    };

    return (
        <div className="form">
            <h2>Регистрация автора:</h2>
            <form onSubmit={submitCheckin}>
                <p>Имя:
                    <input type="text" id="firstname" name="firstname" value={register.firstname} onChange={changeInputRegister} />
                </p>
                <p>Фамилия:
                    <input type="text" id="lastname" name="lastname" value={register.lastname} onChange={changeInputRegister} />
                </p>
                <p>Почта:
                    <input type="text" id="email" name="email" value={register.email} onChange={changeInputRegister} />
                </p>
                <p>Фото:
                    <input type="file" id="image" name="image" onChange={(e) => getFileBytes(e.target.files)} />
                </p>
                <p>Описание:
                    <textarea id="description" name="description" value={register.description} onChange={changeInputRegister} />
                </p>
                <p>Ключевые слова (через пробел):
                    <textarea id="keywords" name="keywords" value={register.keywords} onChange={changeInputRegister} />
                </p>
                <p>Пароль:
                    <input type="password" id="password" name="password" value={register.password} onChange={changeInputRegister}
                /></p>
                <p>Повторите пароль:
                    <input type="password" id="password2" name="password2" value={register.password2} onChange={changeInputRegister} />
                </p>
                <input type="submit" />
            </form>
        </div>
        );

}