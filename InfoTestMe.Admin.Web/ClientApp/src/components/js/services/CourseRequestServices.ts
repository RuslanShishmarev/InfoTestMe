import {getDataByUrlWithHTTPMethod, sendBodyDataByUrl, deleteDataByIdDataAndUrl} from './CommonRequestService'
import requestUrl from '../../../RequestUrls.json';
import {CourseBodyModel, CoursePageModel, CoursePageShortModel, CourseThemeModel} from '../../interfaces/ICourse';


export async function getCourse(id: number){    
    let response = await getDataByUrlWithHTTPMethod(requestUrl.course.get + `${id}`, requestUrl.methods.get, null);
    return response;
}

export async function createCourse(courseBody: CourseBodyModel, action: () => void) {
    await sendBodyDataByUrl(requestUrl.course.create, requestUrl.methods.post, courseBody, action);
}

export async function updateCourse(courseBody: CourseBodyModel, action: () => void) {
    await sendBodyDataByUrl(requestUrl.course.update, requestUrl.methods.patch, courseBody, action);
}

export async function deleteCourse(courseId: number, action: () => void) {
    await deleteDataByIdDataAndUrl(requestUrl.author.delete, courseId, action);
}

export async function createTheme(newTheme: CourseThemeModel) {
    let newThemeId = await getDataByUrlWithHTTPMethod(requestUrl.courseTheme.create, requestUrl.methods.post, newTheme);
    return newThemeId;
}

export async function updateTheme(newTheme: CourseThemeModel, action: () => void) {
    await sendBodyDataByUrl(requestUrl.courseTheme.update, requestUrl.methods.patch, newTheme, action);
}

export async function deleteTheme(theme: CourseThemeModel, action: () => void) {
    await sendBodyDataByUrl(requestUrl.courseTheme.delete, requestUrl.methods.delete, theme, action);
}

export async function createPage(newPage: CoursePageModel | CoursePageShortModel) {
    let newThemeId = await getDataByUrlWithHTTPMethod(requestUrl.coursePage.create, requestUrl.methods.post, newPage);
    return newThemeId;
}

export async function updatePage(newPage: CoursePageModel | CoursePageShortModel, action: () => void) {
    await sendBodyDataByUrl(requestUrl.coursePage.update, requestUrl.methods.patch, newPage, action);
}

export async function deletePage(page: CoursePageModel | CoursePageShortModel, action: () => void) {
    await sendBodyDataByUrl(requestUrl.coursePage.delete, requestUrl.methods.delete, page, action);
}