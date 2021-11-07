

export interface UpdateAuthorModel {
    visible: boolean
    id: number
    firstname: string
    lastname: string
    email: string
    description: string
    keywords: string
    image: null
    onClose: () => void
    reloadAuthor: () => void
}

export interface AuthorBodyModel {
    id: number,
    firstname: string,
    lastname: string,
    email: string,
    description: string,
    keywords: string[],
    image: Uint8Array,
    password: string,
}