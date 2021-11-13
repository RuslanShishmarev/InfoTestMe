

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
export interface CourseFullBodyModel {
    id: number
    name: string
    description: string
    image: Uint8Array
    themes: CourseThemeModel[]
}
export interface CourseEditorModel {
    courseId: number
    name: string
    themeList: CourseThemeListModel
    selectedPage: CoursePageModel
}

export interface CourseThemeCreateModel {
    visible: boolean
    courseId: number
    name: string
    onClose: () => void
    reloadCourseThemes: () => void
}

export interface CourseThemeModel {
    id: number
    courseId: number
    name: string
    pages: CoursePageShortModel[]
}

export interface CourseThemeListModel {
    courseId: number
    themes: CourseThemeModel[]
    deleteTheme: () => void;
}

export interface CoursePageShortModel {
    id: number
    themeId: number
    courseId: number
    name: string
}

export interface CoursePageModel {
    id: number
    themeId: number
    courseId: number
    name: string
    link: string
    audioFileName: string
    audioFile: Uint8Array
    blocks: CourseBlockModel[]
}

export interface CourseBlockModel {
    id: number
    pageId: number
    courseId: number
    text: string
    image: Uint8Array
}