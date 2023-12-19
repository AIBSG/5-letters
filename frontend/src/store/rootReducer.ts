import {combineReducers} from "@reduxjs/toolkit";
import {mainReducer} from "./reducers/mainReducer";

export const rootReducer = combineReducers({
    main: mainReducer
})