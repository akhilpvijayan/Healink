import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ImageConversionService {

  constructor() { }

  convertImageToDataURL(contentImage: string): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      const decodedData = atob(contentImage);
      const arrayBuffer = new ArrayBuffer(decodedData.length);
      const uint8Array = new Uint8Array(arrayBuffer);
      for (let i = 0; i < decodedData.length; i++) {
        uint8Array[i] = decodedData.charCodeAt(i);
      }
      const blob = new Blob([uint8Array], { type: 'image/jpeg' });
      const reader = new FileReader();
      reader.onload = () => {
        resolve(reader.result as string);
      };
      reader.onerror = (error) => {
        reject(error);
      };
      reader.readAsDataURL(blob);
    });
  }

  byteArrayToFile(byteArray: Uint8Array): File {
    const blob = new Blob([byteArray], { type: 'application/octet-stream' });
    // Generate a unique file name
    const fileName = `file_${Date.now()}.bin`;
    return new File([blob], fileName);
  }
}
