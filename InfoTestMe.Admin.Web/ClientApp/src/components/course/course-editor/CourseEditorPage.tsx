import * as React from 'react';
import { useState } from 'react';
import {CourseBodyModel} from '../../interfaces/ICourse';
/*import requestUrl from '../../../RequestUrls.json';
import words from '../../../LetterMessages.json';
import { selectImageBytesFromFile } from '../../js/services/UIServices';*/
import CourseThemeList from './CourseThemeList';
import '../../css/course-editor.css'
import { useParams } from 'react-router';


export default function CourseEditorPage() {
    const [courseEditor, setCourseEditor] = useState(() => {
        return {
            selectedCourseId: 0,
            course: null,
            themes: null,
            selectedTheme: null,
            selectedPage: null
        }
    });

    const params = useParams();
    courseEditor.selectedCourseId = params.id as number;

    //get full course info
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
    const courseName = "default " + courseEditor.selectedCourseId;
    const courseId = courseEditor.selectedCourseId;

    return (
        <div className="course-editor">
            <div className="main-course-info">
                <h1>{courseName}</h1>
            </div>
            <div className="course-body-editor">
                <CourseThemeList courseId={courseEditor.selectedCourseId} />
                <div className="page-editor">
                    
                </div>
            </div>
        </div>
    );
}