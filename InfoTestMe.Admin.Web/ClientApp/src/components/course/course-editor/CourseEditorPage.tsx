import * as React from 'react';
import { useState } from 'react';
import {CourseBodyModel} from '../../interfaces/ICourse';
/*import requestUrl from '../../../RequestUrls.json';
import words from '../../../LetterMessages.json';
import { selectImageBytesFromFile } from '../../js/services/UIServices';*/
import CourseThemeList from './CourseThemeList';
import '../../css/course-editor.css'


export default function CourseEditorPage(course: CourseBodyModel | null) {
    const [courseEditor, setCourseEditor] = useState(() => {
        return {
            course: null,
            themes: null,
            selectedTheme: null,
            selectedPage: null
        }
    });

    //courseEditor.course = course;

    const openSelectedPageInEditor = (pageId: number) => {

        /*get page from backend by id */
        let pageById = null;

        setCourseEditor(prev => {
            return {
                ...prev,
                selectedPage: pageById
            }
        });
    }
    const courseName = courseEditor.course == null ? "default": (courseEditor.course as CourseBodyModel).name;
    const courseId = courseEditor.course == null ? 0: (courseEditor.course as CourseBodyModel).id;

    return (
        <div className="course-editor">
            <div className="main-course-info">
                <h1>{courseName}</h1>
            </div>
            <div className="course-body-editor">
                <CourseThemeList courseId={courseId} />
                <div className="page-editor">
                    
                </div>
            </div>
        </div>
    );
}