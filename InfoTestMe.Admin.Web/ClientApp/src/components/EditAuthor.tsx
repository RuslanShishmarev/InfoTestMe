import * as React from 'react';
import { useState, useCallback  } from 'react';
import requestUrl from '../RequestUrls.json';
import {updateAuthor}  from './js/services/AuthorRequestService';
import {UpdateAuthorModel, AuthorBodyModel} from './interfaces/IAuthor';
import {selectImageBytesFromFile} from '../components/js/services/UIServices';
import words from '../LetterMessages.json';


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
    reloadAuthor,
}: UpdateAuthorModel) => {
    
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
            reloadAuthor: reloadAuthor,
        }
    });
    editer.visible = visible;
    editer.id = id;

    const submitCheckin = event => {
        event.preventDefault();
        if (editer.email == "" || editer.email.includes("@") == false) {
            alert(words.messages.author.errors.nullEmail);
        } else if (editer.password !== editer.password2) {
            alert(words.messages.author.errors.checkPassword);
        } else if (editer.password.length < 4) {
            alert(words.messages.author.errors.shortPassword);
        } else {

            const author: AuthorBodyModel = {
                id: editer.id,
                firstname: editer.firstname,
                lastname: editer.lastname,
                email: editer.email,
                description: editer.description,
                keywords: editer.keywords.split(' '),
                image: editer.image == null ? null : editer.image.toString(),
                password: editer.password,
            };

            updateAuthor(author, reloadAuthor);
            onClose();
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

    const setEditerImage = (bytes: any) => {
        setEditer(prev => { 
            return {
                ...prev,
                image: bytes
            }
        })
    }
    
    const getFileBytes = (files) => {        
        let labelFileName = document.querySelector('#loadImageName') as HTMLSpanElement;
        selectImageBytesFromFile(files[0], labelFileName, setEditerImage);
      }

    if (!editer.visible) return null;

    return (
        <div className="modal-back">
            <div className="modal-form edit-author-form" style={{width: '500px', height: '500px'}}>
                <h2>{words.actions.editAuthor}:</h2>
                <button className='common-btn' onClick={editer.onClose}>{words.actions.close}</button>
                <form onSubmit={submitCheckin}>
                    <p>{words.tags.author.properties.firstname}:</p>
                    <input type="text" id="firstname" name="firstname" value={editer.firstname} onChange={changeInputRegister} />
                    
                    <p>{words.tags.author.properties.lastname}:</p>
                    <input type="text" id="lastname" name="lastname" value={editer.lastname} onChange={changeInputRegister} />
                    
                    <p>{words.tags.author.properties.email}:</p>
                    <input type="text" id="email" name="email" value={editer.email} onChange={changeInputRegister} />
                    
                    <p>{words.words.common.image}:</p>
                    <div className='load-file-btn'>
                        <label>
                            <input type="file" accept="image/*"  id="loadImage" name="image" onChange={(e) => getFileBytes(e.target.files)} />
                            <span id="loadImageName">{words.actions.selectFile}</span>
                        </label>
                    </div>
                    
                    <p>{words.tags.author.properties.description}:</p>
                    <textarea id="description" name="description" value={editer.description} onChange={changeInputRegister} />
                    
                    <p>{words.tags.author.properties.keywords} {words.tags.author.properties.keywordsAt}:</p>
                    <textarea id="keywords" name="keywords" value={editer.keywords} onChange={changeInputRegister} />
                    
                    <p>{words.tags.author.properties.password}:</p>
                    <input type="password" id="password" name="password" value={editer.password} onChange={changeInputRegister}/>

                    <p>{words.actions.passwordRepeat}:</p>
                    <input type="password" id="password2" name="password2" value={editer.password2} onChange={changeInputRegister} />
                    
                    <input className='common-btn' type="submit" />
                </form>                
            </div>
        </div>
    );

}

export default EditAuthor;