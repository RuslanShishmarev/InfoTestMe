import {getDataByUrlWithHTTPMethod, sendBodyDataByUrl, deleteDataByIdDataAndUrl} from './CommonRequestService'
import requestUrl from '../../../RequestUrls.json';
import {CourseBodyModel} from '../../interfaces/ICourse';


export async function getCourse(){    
    let authorResponse = await getDataByUrlWithHTTPMethod(requestUrl.course.get, requestUrl.methods.get, null);
    return authorResponse;
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
