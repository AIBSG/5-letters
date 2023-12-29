import {letterStatus} from "./letterStatus";

export type MainReducerState = {
    words: letterInfo[][],
    rowIndex: number,
    letterIndex: number,
}

export type letterInfo = {
    value?: string,
    status?: typeof letterStatus,
}