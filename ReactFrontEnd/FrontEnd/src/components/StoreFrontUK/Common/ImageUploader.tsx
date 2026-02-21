import { useRef, useState } from 'react';

interface ImageUploaderProps
{
  entityKey: string | number;  
}

export function ImageUploader({entityKey} : ImageUploaderProps) {
    
    const [files, setFiles] = useState<File[]>([]);
    const fileInputRef = useRef<HTMLInputElement | null>(null);

    const uploadImages = async (files: File[]) => {
        const formData = new FormData();
        formData.append('entityKey', entityKey.toString());

        for (const file of files) {
            formData.append('files', file); // must match FilesInterceptor('files')
        }

        const response = await fetch('http://localhost:3000/images/upload', {
            method: 'POST',
            body: formData,
        });

        if (!response.ok) {
            throw new Error(`Upload failed: ${response.statusText}`);
        }

        return await response.json();
    }

    const handleUpload = async () => {
        try {
            const result = await uploadImages(files);
            console.log('Upload result:', result);
        } 
        catch (err) {
            console.error(err);
        }
    };

    const handleClick = () => {
      fileInputRef.current?.click();
    };


  return (
    <div className="container-fluid d-flex justify-content-end p-0 gap-2">
      <div>
        <input type="file" ref={fileInputRef} style={{ display: "none" }} onChange={(e) => setFiles(Array.from(e.target.files || []))} />

        <button className="btn btn-outline-primary" onClick={handleClick}>Select Images</button>
        
        {
        files.length > 0 && 
        <>
          <span className="mx-2">{files[0].name}</span>
          <button className="btn btn-outline-success ms-2" onClick={handleUpload}>Upload</button>
        </>          
        } 
          
          
      

      </div>
    </div>
  );
}