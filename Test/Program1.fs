//Бушуев Никита Николаевич БАС-1(2024)
//Вариант 2
open System

printfn "Введите кол-во элементов списка"
let n = int(Console.ReadLine())

let addList n =
    if n = 0 then 
        printfn "Список пуст"
        []
    elif n < 0 then 
        printfn "Кол-во элементов не может быть отрицательным"
        []
    else
        printfn "Введите элемент"
        let a = Console.ReadLine()
        [for i in 1..n do yield a]

[<EntryPoint>]
let main argv=
    if n < 0 then 
        printfn "Кол-во элементов не может быть отрицательным"
        0
    else
        let result = addList n
        printfn "Список из n одинаковых элементов: %A" result
        0