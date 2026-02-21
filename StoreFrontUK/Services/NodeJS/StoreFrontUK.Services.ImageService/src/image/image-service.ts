import { Injectable } from '@nestjs/common';
import { HttpService } from '@nestjs/axios';
import { firstValueFrom } from 'rxjs';
import FormData from 'form-data';

@Injectable()
export class ImageWorkflowService {
  constructor(private readonly http: HttpService) {}

  async uploadToBlobService(entityKey: string, file: Express.Multer.File) {
    const formData = new FormData();
    formData.append('entityKey', entityKey);
    formData.append('files', file.buffer, file.originalname);

    const response = await firstValueFrom(
      this.http.post('http://localhost:3001', formData, {
        headers: formData.getHeaders(),
      }),
    );

    return response.data as string;
  }
}
