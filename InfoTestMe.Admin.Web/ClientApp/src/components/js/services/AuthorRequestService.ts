import {doActionWithDataByUrlWithToken} from './CommonRequestService'
import requestUrl from '../../../RequestUrls.json';

export async function getAuthor(){    
    let authorResponse = await doActionWithDataByUrlWithToken(requestUrl.author.get, requestUrl.methods.get, null);    
    return authorResponse;
}


export interface AuthorBody {
    id: number,
    firstname: string,
    lastname: string,
    email: string,
    description: string,
    keywords: string[],
    image: Uint8Array,
    password: string,
}

export async function createAuthor(authorBody: AuthorBody){
    await doActionWithDataByUrlWithToken(requestUrl.author.create, requestUrl.methods.post, authorBody);
}

export async function updateAuthor(authorBody: AuthorBody){
    await doActionWithDataByUrlWithToken(requestUrl.author.update, requestUrl.methods.patch, authorBody);
}

export async function deleteAuthor(authorId: number){
    await doActionWithDataByUrlWithToken(requestUrl.author.delete + authorId, requestUrl.methods.delete, null);
}