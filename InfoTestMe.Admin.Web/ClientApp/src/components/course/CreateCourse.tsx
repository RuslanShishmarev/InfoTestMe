import * as React from 'react';
import { useState } from 'react';
import requestUrl from '../../RequestUrls.json';
import { CourseCreateModel, CourseBodyModel } from '../interfaces/ICourse';
import words from '../../LetterMessages.json';
import { selectImageBytesFromFile } from '../js/services/UIServices';
import {createCourse} from '../js/services/CourseRequestServices';

export default function CreateCourse(newCourseModel: CourseCreateModel){
    const [courseModel, setCourseModel ] = useState(() => {
        return {
            visible: false,
            name: '',
            description: '',
            image: null,
            onClose: newCourseModel.onClose,
            reloadAuthor: newCourseModel.reloadAuthorPage
        }
    });

    courseModel.visible = newCourseModel.visible;
    

    const submitCreateCourse = async event => {
        event.preventDefault();

        if(courseModel.name.replace(' ', '').length === 0)
            alert(words.messages.course.errors.nullName);

        if(courseModel.description.replace(' ', '').length === 0)
            alert(words.messages.course.errors.nullName);
        
        else {
            const course: CourseBodyModel = {
                id: 0,
                name: courseModel.name,
                description: courseModel.description,
                image: courseModel.image == null ? null : courseModel.image.toString(),
            }

            await createCourse(course, courseModel.reloadAuthor)
            courseModel.onClose();
        }
    }

    const changeInput = event => {
        event.persist()
        setCourseModel(prev => {
            return {
                ...prev,
                [event.target.name]: event.target.value,
            }
        })
    };    

    const setCourseModelImage = (bytes: any) => {
        setCourseModel(prev => {
            return {
                ...prev,
                image: bytes
            }
        });
    }

    const getCourseImage = (files) => {
        let labelFileName = document.querySelector('#loadImageName') as HTMLSpanElement;
        selectImageBytesFromFile(files[0], labelFileName, setCourseModelImage);
    };

    if (!courseModel.visible) return null;

    return(
        <div className="modal-back">
            <div className="modal-form" style={{width: '500px', height: '500px'}}>
                <button className='common-btn' onClick={courseModel.onClose}>{words.actions.close}</button>
                <form onSubmit={submitCreateCourse}>
                    <p>{words.words.common.name}</p>
                    <input type="text" id="name" name="name" value={courseModel.name} onChange={changeInput} />
                    
                    <p>{words.words.common.image}</p>
                    <div className='load-file-btn'>
                        <label>
                            <input type="file" accept="image/*"  id="loadImage" name="image" 
                                onChange={(e) => getCourseImage(e.target.files)} />
                            <span id="loadImageName">{words.actions.selectFile}</span>
                        </label>
                    </div>

                    <p>{words.words.common.description}</p>
                    <textarea id="description" name="description" value={courseModel.description} onChange={changeInput} />   
                    <input className='common-btn' type="submit" />                 
                </form>
            </div>
        </div>
    );
}