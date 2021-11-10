import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Register from './components/Register';
import SingIn from './components/SingIn';
import AuthorPage from './components/AuthorPage';
import CourseEditorPage from './components/course/course-editor/CourseEditorPage';


import './custom.css'
import './main-style.css';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/register' component={Register} />
        <Route path='/singin' component={SingIn} />
        <Route path='/mypage' component={AuthorPage} />
        <Route path='/courseEditor/:id' component={CourseEditorPage}/>
    </Layout>
);
