import React from "react";
import styles from "./keyboard.module.css"
import {letterStatus} from "../../models/letterStatus";
import {useAppDispatch, useAppSelector} from "../../hooks/storeHooks";
import {setLetter, setLetterIndex, setRowIndex} from "../../store/reducers/mainReducer";

const arrayOne = ['й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ']
const arrayTwo = ['ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э']
const arrayThree = ['OK', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю', '<<']

let enteredWord = '';
let savedWord = '';
let finalWord: string[] = []

const deleteLastLetter = () => {
    const valueContainer = document.querySelector("#valueContainer")
    enteredWord = enteredWord.slice(0, -1)
    valueContainer!.innerHTML = enteredWord
    console.log('enteredWord in delete', enteredWord)
}
const savedAllLetter = () => {
    const savedContainer = document.querySelector("#savedContainer")
    const valueContainer = document.querySelector("#valueContainer")
    if (enteredWord.length === 5) {
        valueContainer!.innerHTML = enteredWord
        savedWord = valueContainer!.innerHTML
        savedContainer!.innerHTML = savedWord
        console.log('enteredWord in saveWord', savedWord)
        finalWord = Array.from(savedWord)
        console.log('FINAL WORD', finalWord)
        // if (enteredWord === savedWord) {
        //     console.log('entered word === saved word', enteredWord)
        //     while (enteredWord.length !== 0) {
        //         deleteLastLetter()
        //     }
        // }
    }
}
const Keyboard = () => {
    const {letterIndex, rowIndex, words} = useAppSelector(state => state.main)

    const dispatch = useAppDispatch();

    const handleClick = (event: any) => {

        const buttonValue = event.target.innerText
        dispatch(setLetter({
            value: buttonValue,
            status: letterStatus.DEFAULT
        }))
        const nextLetterIndex = letterIndex + 1
        if (nextLetterIndex === words[rowIndex].length) {
            dispatch(setLetterIndex(0))
            dispatch(setRowIndex(rowIndex + 1))
        } else {
            dispatch(setLetterIndex(nextLetterIndex))
        }
    }
    return (
        <div className={styles.container}>
            <div className={styles.keyboardContainer}>
                <div className={styles.keyboardItem}>
                    {arrayOne.map((letter) => {
                        return <button className={styles.buttons} onClick={handleClick}><span className={styles.buttonsSpan}>{letter}</span></button>
                    })}
                </div>
                <div className={styles.keyboardItem}>
                    {arrayTwo.map((letter) => {
                        return <button className={styles.buttons} onClick={handleClick}><span className={styles.buttonsSpan}>{letter}</span></button>
                    })}
                </div>
                <div className={styles.keyboardItem}>
                    {arrayThree.map((letter) => {
                        return <button className={styles.buttons} onClick={handleClick}><span className={styles.buttonsSpan}>{letter}</span></button>
                    })}
                </div>
                {/*<div className={styles.keyboardItem}>*/}
                {/*    <button className={styles.buttons} onClick={savedAllLetter}>--OK--</button>*/}
                {/*</div>*/}
                {/*<div className={styles.keyboardItem}>*/}
                {/*    <button id={'deleteLetter'} className={styles.buttons} onClick={deleteLastLetter}>--BACKSPACE--*/}
                {/*    </button>*/}
                {/*</div>*/}
            </div>
        </div>
    );
};
export default Keyboard;
