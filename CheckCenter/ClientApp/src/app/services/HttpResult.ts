export class HttpResult {
    error: string;
    result: any;
    
    constructor(_error: string, _result: any) {
        this.error = _error;
        this.result = _result;
    }
}

export class HttpResultBuilder {
    private error: string;
    private result: any;

    setError(error: string): void {
        this.error = error;
    }

    setResult(result: any): void {
        this.result = result;
    }

    build(): HttpResult {
        return new HttpResult(this.error, this.result);
    }
}