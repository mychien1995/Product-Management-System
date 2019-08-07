import { ConfigModule, ConfigService } from '../services/shared/config.service';

export class AppSetting {
	BaseApiUrl? : string;
}

export let APP_CONFIG : AppSetting = {};