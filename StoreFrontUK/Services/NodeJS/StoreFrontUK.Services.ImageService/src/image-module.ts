// src/image/image.module.ts
import { Module } from '@nestjs/common';
import { HttpModule } from '@nestjs/axios';
import { ImageController } from './image.controller';
import { ImageWorkflowService } from './image/image-service';

@Module({
  imports: [HttpModule],
  controllers: [ImageController],
  providers: [ImageWorkflowService],
})
export class ImageModule {}
