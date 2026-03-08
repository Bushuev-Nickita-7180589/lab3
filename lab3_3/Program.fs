//Бушуев Никита Николаевич БАС-1(2024)
//Вариант 2
open System
open System.IO

let getFiles directoryPath =
    let rec getAllFiles dir =
        seq {
            let files = Directory.GetFiles(dir) // получаем все файлы в текущей папке
            for file in files do // проходим по каждому файлу
                let ext = Path.GetExtension(file).ToLower() // берем расширение файла
                if ext <> ".txt" then  // если расширение не .txt
                    yield file // добавляем файл в результат
            
            let subDirs = Directory.GetDirectories(dir) // получаем все подпапки
            for subDir in subDirs do // проходим по каждой подпапке
                yield! getAllFiles subDir // заходим в подпапку и добавляем её файлы
        }
    
    getAllFiles directoryPath // запускаем обход с указанной папки

[<EntryPoint>]
let main argv =
    printf "Введите путь: "
    let path = Console.ReadLine()
    
    if Directory.Exists(path) then
        printfn "\nНетекстовые файлы:"
        
        getFiles path  // получаем файлы
        |> Seq.iter (printfn "%s")  // просто печатаем каждый
    
    else
        printfn "Папка не найдена"
    
    0