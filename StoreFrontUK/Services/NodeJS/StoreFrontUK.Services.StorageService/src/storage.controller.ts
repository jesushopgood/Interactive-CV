import { Body, Controller, Post, UploadedFiles } from '@nestjs/common';
import { StorageService } from './storage.service';

@Controller()
export class StorageController {
  constructor(private readonly storageService: StorageService) {}

  @Post()
  async uploadImage(
    @UploadedFiles() files: Express.Multer.File,
    @Body('entityKey') entityKey: string,
  ) {
    const blobUrl = await this.storageService.uploadFile(entityKey, files);
    return blobUrl;
  }
}
