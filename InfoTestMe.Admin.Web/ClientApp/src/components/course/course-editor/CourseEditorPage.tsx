import * as React from 'react';
import { useState } from 'react';
import {CourseBodyModel, CourseFullBodyModel, CourseThemeModel} from '../../interfaces/ICourse';
/*import requestUrl from '../../../RequestUrls.json';
import words from '../../../LetterMessages.json';
import { selectImageBytesFromFile } from '../../js/services/UIServices';*/
import CourseThemeList from './CourseThemeList';
import '../../css/course-editor.css'
import { useParams } from 'react-router';
import { isCurrentUserAuthorized } from '../../js/services/CommonRequestService';
import { getCourse } from '../../js/services/CourseRequestServices';


export default function CourseEditorPage() {
    const [courseEditor, setCourseEditor] = useState(() => {
        return {
            courseId: 0,
            course: null,
            courseName: 'default',
            themes: null,
            selectedTheme: null,
            selectedPage: null
        }
    });
    let isUserAuth: boolean = isCurrentUserAuthorized();

    
    const params = useParams();
    courseEditor.courseId = params.id as number;
    if(!isUserAuth) {
        window.location.replace(`singin`);
        return null;
    }

    const loadCourseData = async () => {
        let course = await getCourse(courseEditor.courseId) as CourseFullBodyModel;
        setCourseEditor(prev => {
            return {
                ...prev,
                course: course,
                courseName: course.name,
                themes: <CourseThemeList courseId={courseEditor.courseId} themes={course.themes} />
            }
        });
    }
    
    //get full course info
    //themes
    //loadCourseData();

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
    const courseId = courseEditor.courseId;

    return (
        
        <div className="course-editor">
            <div className="main-course-info">
                <h1>{courseEditor.courseName}</h1>
                <button onClick={loadCourseData}>Загрузить</button>
            </div>
            <div className="course-body-editor">
                {courseEditor.themes}
                <div className="page-editor">
                    
                </div>
            </div>
        </div>
    );
}