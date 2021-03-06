import requestUrl from '../../../RequestUrls.json';
import words from '../../../LetterMessages.json';

export async function getDataByUrlWithHTTPMethod(url: string, methodType: string, body: any | null) {

    await updateToken();

    let requestOptions;

    body == null ?
    requestOptions = {
        method: methodType,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem('token'),            
        }
    } : requestOptions = {
        method: methodType,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem('token'),            
        },
        body: JSON.stringify(body)
    } 

    //let resultData;
    let response = await fetch(`` + url, requestOptions);
    if(response.ok){
        let json = await response.json();
        return json;
    } else {
        alert(words.messages.request.error + " " + response.status)
    }
}

export async function sendBodyDataByUrl(url:string, methodType: string, body: any, actionOkResponse: () => void) {

    await updateToken();

    const requestOptions = {
        method: methodType,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem('token'),            
        },
        body: JSON.stringify(body)
    } 

    let response = await fetch(`` + url, requestOptions);
    if(response.ok){
        actionOkResponse();
    } else {
        alert(words.messages.request.error + " " + response.status)
    }
}

export async function deleteDataByIdDataAndUrl(url:string, id: number, actionOkResponse: () => void) {

    await updateToken();

    let requestOptions = {
        method: requestUrl.methods.delete,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem('token'),            
        }
    }
    let response = await fetch(`` + url + '/' + id, requestOptions);
    if(response.ok){
        actionOkResponse();
    } else {
        alert(words.messages.request.error + " " + response.status)
    }
}

export async function getToken(login: string, password: string) {

    let singInLP = Buffer.from(login + ":" + password).toString('base64');

    const requestOptions = {
        method: requestUrl.methods.post,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Basic ' + singInLP.toString()
        },
    };
    
    let token = "";

    let response = await fetch(`` + requestUrl.author.singin, requestOptions);

    let json = await response.json();

    token = json.token;
    
    sessionStorage.setItem("token", token.toString());
    sessionStorage.setItem("login", login);
    sessionStorage.setItem("password", password);
    sessionStorage.setItem("singin-time", Date.now().toString());
    
    return token;
}

async function updateToken() {
    
    let sinInDateStr = sessionStorage.getItem('singin-time');
    let now = Date.now();
    let singInAsDate = sinInDateStr !== null ? Number.parseInt(sinInDateStr) :  Date.now();

    let workTime = now - singInAsDate;

    if(workTime > 540000) {
        let login = sessionStorage.getItem('login');
        let password = sessionStorage.getItem('password');    
        
        if(login !== null && password !== null ) {
            let newToken = await getToken(login, password);
            sessionStorage.setItem('singin-time', Date.now().toString());
            if(newToken !== null) sessionStorage.setItem('token', newToken );
        } else {
            window.location.replace(`/singin`);
            return;
        }
    }
}

export function isCurrentUserAuthorized() {
    let token = sessionStorage.getItem('token');
    if(token == '' || token == null) return false;
    return true;
}