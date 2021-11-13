import * as React from 'react';
import { useState } from 'react';
import { CourseThemeListModel,CourseThemeModel} from '../../interfaces/ICourse';
import CourseThemeItem from './CourseThemeItem';
import words from '../../../LetterMessages.json';
import { createTheme } from '../../js/services/CourseRequestServices';


const CourseThemeList = ({courseId = 0, themes = []}) => {
        const [themeList, setThemeList] = useState(() => {
            return {
                courseId: 0,
                themes: [],
            };
        });

        themeList.courseId = courseId;
        themeList.themes = themes as  CourseThemeModel[];

        const addNewTheme = async () => {

            let newTheme: CourseThemeModel = {
                id: 0,
                courseId: themeList.courseId,
                name: "New theme 1",
                pages: []
            };
            /* send to backend new theme*/
            let newThemeId = 0;
            if(themeList.courseId != 0)
                newThemeId = await createTheme(newTheme);
            
            newTheme.id = newThemeId;
            //update ui
            let newThemes = themeList.themes;
            (newThemes as CourseThemeModel[]).push(newTheme);
            
            setThemeList(prev => {
                return {
                    ...prev,
                    themes: newThemes
                }
            });
        }

        return (
            <div className="course-themes">
                <button className="common-btn" onClick={() => addNewTheme}>{words.actions.addNewTheme}</button>
                <div className="course-themes-list">
                    {(themeList.themes as CourseThemeModel[]).map(obj => {
                        return <CourseThemeItem key={obj.id} id={obj.id} name={obj.name} courseId={themeList.courseId} pages={obj.pages}/>
                    })}
                </div>
            </div>
        );

    }

export default CourseThemeList;