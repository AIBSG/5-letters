import {createSlice} from "@reduxjs/toolkit";
import {MainReducerState} from "../../models/stateModels";

const initialState:MainReducerState = {
    words: [
        [{},{},{},{},{}],
        [{},{},{},{},{}],
        [{},{},{},{},{}],
        [{},{},{},{},{}],
        [{},{},{},{},{}]
    ],
    rowIndex: 0,
    letterIndex: 0,
}

const MainReducer = createSlice({
    name: 'gameFiveWords',
    initialState,
    reducers: {
        setLetter(state, action){
            state.words[state.rowIndex][state.letterIndex] = action.payload
        },
        setRowIndex(state, action){
            state.rowIndex = action.payload
        },
        setLetterIndex(state, action){
            state.letterIndex = action.payload
        },
    },
})

export const  {setLetter, setLetterIndex, setRowIndex} = MainReducer.actions
export const mainReducer = MainReducer.reducer

