import * as React from 'react';
import { useState } from 'react';
import { CourseThemeListModel,CourseThemeModel} from '../../interfaces/ICourse';
import CourseThemeItem from './CourseThemeItem';
import words from '../../../LetterMessages.json';

const CourseThemeList = ({courseId = 0}) => {
        const [themeList, setThemeList] = useState(() => {
            return {
                courseId: 0,
                themes: [],
            };
        });

        themeList.courseId = courseId;


        const addNewTheme = () => {

            let newTheme = {
                id: themeList.themes.length + 1,
                name: "New theme 1"
            };

            let newThemes = themeList.themes;
            newThemes.push(newTheme);
            /* send to backend new theme
            ...
            */
            //update ui
            setThemeList(prev => {
                return {
                    ...prev,
                    themes: newThemes
                }
            });
        }

        return (
            <div className="course-themes">
                <button className="common-btn" onClick={addNewTheme}>{words.actions.addNewTheme}</button>
                <div className="course-themes-list">
                    {themeList.themes.map(obj => {
                        return <CourseThemeItem key={obj.id} name={obj.name}/>
                    })}
                </div>
            </div>
        );

    }

export default CourseThemeList;