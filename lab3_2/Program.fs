//Бушуев Никита Николаевич БАС-1(2024)
//Вариант 2
open System

let rec readDigit prompt =
    printf "%s" prompt
    match Int32.TryParse(Console.ReadLine()) with
    | (true, n) when n >= 0 && n <= 9 -> n
    | (true, n) -> 
        printfn "Ошибка! %d не является цифрой от 0 до 9!" n
        readDigit prompt
    | (false, _) -> 
        printfn "Ошибка! Введите число!"
        readDigit prompt

let rec readNumber prompt =
    printf "%s" prompt
    match Int32.TryParse(Console.ReadLine()) with
    | (true, n) -> n
    | (false, _) -> 
        printfn "Ошибка! Введите число!"
        readNumber prompt

let readSeq() =
    let n = readNumber "Введите количество элементов: "
    
    seq {
        for i in 1..n do
            let x = readNumber (sprintf "\nВведите элемент %d: " i)
            yield x
    }

[<EntryPoint>]
let main argv =
    let numbers = readSeq()
    let digit = readDigit "\nВведите цифру (0-9): "
    
    let sum = 
        Seq.fold (fun acc x -> 
            if abs x % 10 = digit then acc + x else acc
        ) 0 numbers
    
    printfn "Сумма элементов, оканчивающихся на %d: %d" digit sum
    
    printfn "\nНажмите любую клавишу..."
    Console.ReadKey() |> ignore
    0