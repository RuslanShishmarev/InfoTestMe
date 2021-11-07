

export interface CourseCreateModel {
    visible: boolean
    name: string
    description: string
    image: Uint8Array
    onClose: () => void
    reloadAuthorPage: () => void
}

export interface CourseBodyModel {
    id: number
    name: string
    description: string
    image: Uint8Array
}