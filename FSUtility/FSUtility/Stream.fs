namespace FSUtility

open System
open System.IO
open System.Threading
open System.Threading.Tasks

module Stream =

    let private boolToOption (value:bool):unit option =
        match value with
        | true -> Some()
        | false -> None

    let(|Read|_|) (stream:Stream) =
        stream.CanRead
        |> boolToOption
        
    let(|Seek|_|) (stream:Stream) =
        stream.CanSeek
        |> boolToOption
                
    let(|Timeout|_|) (stream:Stream) =
        stream.CanTimeout
        |> boolToOption
                        
    let(|Write|_|) (stream:Stream) =
        stream.CanWrite
        |> boolToOption

    let Null = Stream.Null

    let length (stream:Stream):int64 = stream.Length
    
    let position (stream:Stream):int64 = stream.Position
    
    let readTimeout (stream:Stream):int = stream.ReadTimeout
        
    let writeTimeout (stream:Stream):int = stream.WriteTimeout
    
    let beginRead (state:obj) (callback:AsyncCallback) (count:int) (index:int) (buffer:byte array) (stream:'a when 'a :> Stream):IAsyncResult = stream.BeginRead(buffer, index, count, callback, state)
    
    let beginWrite (state:obj) (callback:AsyncCallback) (count:int) (index:int) (buffer:byte array) (stream:'a when 'a :> Stream):IAsyncResult = stream.BeginWrite(buffer, index, count, callback, state)

    let close (stream:'a when 'a :> Stream):unit = stream.Close()
    
    let endRead (asyncResult:IAsyncResult) (stream:'a when 'a :> Stream):int = stream.EndRead(asyncResult)
    
    let endWrite (asyncResult:IAsyncResult) (stream:'a when 'a :> Stream):unit  = stream.EndWrite(asyncResult)
    
    let flush (stream:'a when 'a :> Stream):unit = stream.Flush()
    
    let read (count:int) (index:int) (buffer:byte array) (stream:'a when 'a :> Stream):int = stream.Read(buffer, index, count)
    
    let readAsync (cancellationTokenOption:CancellationToken option) (count:int) (index:int) (buffer:byte array) (stream:'a when 'a :> Stream):Task<int> =
        match cancellationTokenOption with
        | None -> stream.ReadAsync(buffer, index, count)
        | Some(cancellationToken:CancellationToken) -> stream.ReadAsync(buffer, index, count, cancellationToken)
        
    let readByte (stream:'a when 'a :> Stream):int = stream.ReadByte()
    
    let write (count:int) (index:int) (buffer:byte array) (stream:'a when 'a :> Stream):unit = stream.Write(buffer, index, count)
    
    let writeAsync (cancellationTokenOption:CancellationToken option) (count:int) (index:int) (buffer:byte array) (stream:'a when 'a :> Stream):Task =
        match cancellationTokenOption with
        | None -> stream.WriteAsync(buffer, index, count)
        | Some(cancellationToken:CancellationToken) -> stream.WriteAsync(buffer, index, count, cancellationToken)
        
    let writeByte (value:byte) (stream:'a when 'a :> Stream):unit = stream.WriteByte(value)

