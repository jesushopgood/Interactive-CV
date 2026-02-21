// src/image/image.controller.ts
import {
  Controller,
  Post,
  UploadedFiles,
  UseInterceptors,
  Body,
  Get,
} from '@nestjs/common';
import { FilesInterceptor } from '@nestjs/platform-express';
import { ImageWorkflowService } from './image/image-service';

@Controller('images')
export class ImageController {
  constructor(private readonly imageWorkflowService: ImageWorkflowService) {}

  @Post('upload')
  @UseInterceptors(FilesInterceptor('files'))
  async uploadImages(
    @UploadedFiles() files: Express.Multer.File[],
    @Body('entityKey') entityKey: string,
  ) {
    return await this.imageWorkflowService.uploadToBlobService(
      entityKey,
      files[0],
    );
  }

  @Get('ping')
  ping() {
    return 'Pong';
  }
}
