import {getDataByUrlWithHTTPMethod, sendBodyDataByUrl, deleteDataByIdDataAndUrl} from './CommonRequestService'
import requestUrl from '../../../RequestUrls.json';
import {CourseBodyModel, CourseThemeModel} from '../../interfaces/ICourse';


export async function getCourse(id: number){    
    let response = await getDataByUrlWithHTTPMethod(requestUrl.course.get + `/${id}`, requestUrl.methods.get, null);
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