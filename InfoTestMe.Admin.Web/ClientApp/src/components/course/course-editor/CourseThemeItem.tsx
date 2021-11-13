import * as React from 'react';
import { useState } from 'react';
import { CoursePageShortModel } from '../../interfaces/ICourse';
import { createPage } from '../../js/services/CourseRequestServices';

const CourseThemeItem = ({
    id = 0,
    courseId = 0,
    name = ''   ,
    pages = [] 
}) => {
    
    const [theme, setTheme] = useState(() => {
        return {
            id: 0,
            courseId: 0,
            name: '',
            pages: []
        }
    });

    theme.id = id;
    theme.name = name;
    theme.courseId = courseId;

    const addNewPage = async () => {
        let newPage: CoursePageShortModel = {
            id: 0,
            themeId: theme.id,
            courseId: theme.courseId,
            name: "New page 1"
        };
        
        
        if(theme.id !== 0) {
            //send to backend new page
            let newPageId = 0;
            newPage.id = newPageId;
            await createPage(newPage);
        }

        //update ui
        let newPages = theme.pages;
        (newPages as CoursePageShortModel[]).push(newPage);
        
        setTheme(prev => {
            return {
                ...prev,
                pages: newPages
            }
        });
    }

    return (
        <div className="theme-item">
            <div className="theme-name">
                <p>{theme.name}</p>
                <button className="round-btn-sm theme-btn" onClick={() => addNewPage}>+</button>
            </div>
            <div className="theme-pages">
                {theme.pages.map(p => {
                    return (
                        <button className="btn page-item-btn">{(p as CoursePageShortModel).name}</button>
                    );
                })}
            </div>
        </div>
    );
}

export default CourseThemeItem;