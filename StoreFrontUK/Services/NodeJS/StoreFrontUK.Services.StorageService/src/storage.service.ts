// src/storage/storage.service.ts
import { Injectable } from '@nestjs/common';
import { BlobServiceClient, ContainerClient } from '@azure/storage-blob';
import { ConfigService } from '@nestjs/config';
import { EntityId } from '../../Shared/types/shared-types';

@Injectable()
export class StorageService {
  private readonly _conn: string;
  private readonly _blobService: BlobServiceClient;
  private _container: ContainerClient;

  constructor(private configService: ConfigService) {
    this._conn = this.configService.get<string>(
      'AZURE_STORAGE_CONNECTION_STRING',
    )!;
    this._blobService = BlobServiceClient.fromConnectionString(this._conn);
  }

  async uploadFile(entityId: EntityId, file: Express.Multer.File) {
    this._container = this._blobService.getContainerClient('incoming');
    await this._container.createIfNotExists();

    const blobName = `${entityId}/${file.originalname}`;
    const blockBlob = this._container.getBlockBlobClient(blobName);
    await blockBlob.uploadData(file.buffer);
    return blockBlob.url;
  }
}
