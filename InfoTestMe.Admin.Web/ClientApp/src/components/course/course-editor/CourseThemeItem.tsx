import * as React from 'react';
import { useState } from 'react';

const CourseThemeItem = ({
    name = ''
}) => {
    
    const [theme, setTheme] = useState(() => {
        return {
            name: '',
            pages: []
        }
    });

    theme.name = name;

    const addNewPage = () => {
        let newPage = {
            name: "New page 1"
        };

        let newPages = theme.pages;
        newPages.push(newPage);
        /* send to backend new theme
        ...
        */
        //update ui
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
                <button className="round-btn-sm theme-btn" onClick={addNewPage}>+</button>
            </div>
            <div className="theme-pages">
                {theme.pages.map(p => {
                    return (
                        <button className="common-btn page-item-btn">{p.name}</button>
                    );
                })}
            </div>
        </div>
    );
}

export default CourseThemeItem;