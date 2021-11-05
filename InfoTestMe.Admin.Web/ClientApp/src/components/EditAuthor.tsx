import * as React from 'react';
import { useState } from 'react';
import './css/EditAuthor.css';


// интерфейс для пропсов
interface EditAuthorProps {
    visible: boolean
    id: number
    firstname: string
    lastname: string
    email: string
    description: string
    keywords: string
    image: null
    onClose: () => void
  }


const EditAuthor = ({
    visible = false,
    id = 0,
    firstname = '',
    lastname = '',
    email = '',
    description = '',
    keywords = '',
    image = null,
    onClose,
}: EditAuthorProps) => {
    
    const [editer, setEditer] = useState(() => {
        return {
            visible: false,
            id: 0,
            firstname: '',
            lastname: '',
            email: '',
            description: '',
            keywords: '',
            image: null,
            password: '',
            password2: '',
            onClose: onClose,
        }
    });
    editer.visible = visible;
    editer.id = id;

    const submitCheckin = event => {
        event.preventDefault();
        if (editer.email == "" || editer.email.includes("@") == false) {
            alert("Неправильная почта");
        } else if (editer.password !== editer.password2) {
            alert("Введите одинаковый пароль");
        } else if (editer.password.length < 4) {
            alert("Пароль должен содержать больше 4 символов");
        } else {
            const requestOptions = {
                method: 'PATCH',
                headers: { 
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + sessionStorage.getItem('token') 
                },
                body: JSON.stringify(
                    {
                        id: editer.id,
                        firstname: editer.firstname,
                        lastname: editer.lastname,
                        email: editer.email,
                        description: editer.description,
                        keywords: editer.keywords.split(' '),
                        image: editer.image == null ? null : editer.image.toString(),
                        password: editer.password,
                    })
            };

            fetch(`api/accounts/author`, requestOptions).then(response => {
                if (response.status !== 200) {
                    alert('Some error. Status code ' + response.status);    
                    return;                   
                }   
                window.location.replace(`/mypage`);   
            })
            .catch(function (err) {
                alert('Register error');
            });
        }
    };

    const changeInputRegister = event => {
        event.persist()
        setEditer(prev => {
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
            setEditer(prev => { 
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

    if (!editer.visible) return null

    return (
        <div className="edit-author">
            <div className="edit-form" >
                <h2>Редактирование автора:</h2>
                <button className='common-btn' onClick={editer.onClose}>Закрыть</button>
                <form onSubmit={submitCheckin}>
                    <p>Имя:</p>
                    <input type="text" id="firstname" name="firstname" value={editer.firstname} onChange={changeInputRegister} />
                    
                    <p>Фамилия:</p>
                    <input type="text" id="lastname" name="lastname" value={editer.lastname} onChange={changeInputRegister} />
                    
                    <p>Почта:</p>
                    <input type="text" id="email" name="email" value={editer.email} onChange={changeInputRegister} />
                    
                    <p>Фото:</p>
                    <div className='load-file-btn'>
                        <label>
                            <input type="file" accept="image/*"  id="loadImage" name="image" onChange={(e) => getFileBytes(e.target.files)} />
                            <span id="loadImageName">Выберите файл</span>
                        </label>
                    </div>
                    
                    <p>Описание:</p>
                    <textarea id="description" name="description" value={editer.description} onChange={changeInputRegister} />
                    
                    <p>Ключевые слова (через пробел):</p>
                    <textarea id="keywords" name="keywords" value={editer.keywords} onChange={changeInputRegister} />
                    
                    <p>Пароль:</p>
                    <input type="password" id="password" name="password" value={editer.password} onChange={changeInputRegister}/>

                    <p>Повторите пароль:</p>
                    <input type="password" id="password2" name="password2" value={editer.password2} onChange={changeInputRegister} />
                    
                    <input className='common-btn' type="submit" />
                </form>                
            </div>
        </div>
    );

}

export default EditAuthor;