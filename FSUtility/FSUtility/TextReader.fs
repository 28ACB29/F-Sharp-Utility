namespace FSUtility

open System
open System.IO
open System.Threading.Tasks

module TextReader =

    let close (reader:'a when 'a :> TextReader):unit = reader.Close()
    
    let peek (reader:'a when 'a :> TextReader):int = reader.Peek()
    
    let read (bufferIndexCountOption:(char array * int * int) option) (reader:'a when 'a :> TextReader):int =
        match bufferIndexCountOption with
        | None -> reader.Read()
        | Some(buffer:char array, index:int, count:int) -> reader.Read(buffer, index, count)
    
    let readAsync (count:int) (index:int) (buffer:char array) (reader:'a when 'a :> TextReader):Task<int> = reader.ReadAsync(buffer, index, count)
    
    let readBlock (count:int) (index:int) (buffer:char array) (reader:'a when 'a :> TextReader):int = reader.ReadBlock(buffer, index, count)
    
    let readBlockAsync (count:int) (index:int) (buffer:char array) (reader:'a when 'a :> TextReader):Task<int> = reader.ReadBlockAsync(buffer, index, count)
    
    let readLine (reader:'a when 'a :> TextReader):string = reader.ReadLine()
    
    let readLineAsync (reader:'a when 'a :> TextReader):Task<string> = reader.ReadLineAsync()
    
    let readToEnd (reader:'a when 'a :> TextReader):string = reader.ReadToEnd()
    
    let readToEndAsync (reader:'a when 'a :> TextReader):Task<string> = reader.ReadToEndAsync()
    
    let synchronized (reader:'a when 'a :> TextReader):TextReader = TextReader.Synchronized(reader)