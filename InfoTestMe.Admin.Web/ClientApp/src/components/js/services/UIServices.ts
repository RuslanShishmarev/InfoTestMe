export function selectImageBytesFromFile(file: Blob | ImageData | any, labelFileName: HTMLElement, setState: (bytes: any) => void){
    let reader = new FileReader();
    let result;
    reader.onload = function(){
        let arrayBuffer = this.result as ArrayBuffer;
        let bytes = new Uint8Array(arrayBuffer);
        let fileName = file.name;
        labelFileName.innerText = fileName == null ? "Nothing" : fileName;
        setState(bytes);
    }
    reader.readAsArrayBuffer(file);
}