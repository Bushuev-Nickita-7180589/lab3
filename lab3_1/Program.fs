//Бушуев Никита Николаевич БАС-1(2024)
//Вариант 2
open System

// Функция для ввода ЛЮБОГО ЧИСЛА
let rec readNumber prompt =
    printf "%s" prompt
    
    match Int32.TryParse(Console.ReadLine()) with
    | (true, n) -> n
    | (false, _) -> 
        printfn "Ошибка! Введите число!"
        readNumber prompt

// Функция создания последовательности чисел
let readSeq() =
    let n = readNumber "Введите количество элементов: "
    
    // Сразу читаем все числа в список
    let data = [ for i in 1..n do
                    let x = readNumber (sprintf "Введите элемент %d: " i)
                    yield x ]
    
    seq { yield! data }  // превращаем в последовательность

let lastDigit x = abs x % 10

[<EntryPoint>]
let main argv =
    let numbers = readSeq()  // все числа уже введены
    
    let lastDigits = Seq.map lastDigit numbers
    
    // Цикл для вывода всех цифр через пробел
    printf "Последние цифры: "
    for d in lastDigits do
        printf "%d " d
    
    printfn "\nНажмите любую клавишу..."
    Console.ReadKey() |> ignore
    0