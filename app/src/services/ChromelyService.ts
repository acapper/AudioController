
export default class ChromelyService {

	constructor() { }

	get<T>(url: string, parameters?: any): Promise<T> {
		const request = {
			"method": "GET",
			"url": url,
			"parameters": parameters,
			"postData": null
		};

		return this.messageRouterQuery<T>(url, request);
	}

	post<T>(url: string, postData?: any, parameters?: any): Promise<T> {
		const request = {
			"method": "POST",
			"url": url,
			"parameters": parameters,
			"postData": postData
		};

		return this.messageRouterQuery<T>(url, request);
	}

	openExternalUrl(url: string) {
		const link = document.createElement('a');
		link.href = url;
		document.body.appendChild(link);
		link.click();
	}

	private messageRouterQuery<T>(url: string, request: any): Promise<T> {
		return new Promise(
			(resolve, reject) => {
				const chromelyWindow = window as any;
				chromelyWindow.cefQuery({
					request: JSON.stringify(request),
					onSuccess: (response: any) => {
						const jsonData = JSON.parse(response);
						if (jsonData.ReadyState == 4 && jsonData.Status == 200) {
							resolve(jsonData.Data);
						} else {
							reject({ response });
						}
					},
					onFailure: (err: any, msg: string) => {
						reject({ err, msg });
					}
				});
			}
		);
	}
}


