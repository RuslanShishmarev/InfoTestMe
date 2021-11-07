import {getDataByUrlWithHTTPMethod, sendBodyDataByUrl, deleteDataByIdDataAndUrl} from './CommonRequestService'
import requestUrl from '../../../RequestUrls.json';
import { AuthorBodyModel } from '../../interfaces/IAuthor';

export async function getAuthor(){    
    let authorResponse = await getDataByUrlWithHTTPMethod(requestUrl.author.get, requestUrl.methods.get, null);    
    return authorResponse;
}


export async function createAuthor(authorBody: AuthorBodyModel, action: () => void){
    await sendBodyDataByUrl(requestUrl.author.create, requestUrl.methods.post, authorBody, action);
}

export async function updateAuthor(authorBody: AuthorBodyModel, action: () => void){
    await sendBodyDataByUrl(requestUrl.author.update, requestUrl.methods.patch, authorBody, action);
}

export async function deleteAuthor(authorId: number, action: () => void){
    await deleteDataByIdDataAndUrl(requestUrl.author.delete, authorId, action);
}