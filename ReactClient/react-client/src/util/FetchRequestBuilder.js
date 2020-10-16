const POST = "POST"
const GET = "GET"
const DELETE = "DELETE"

async function requestUrlBuilder(url,params){
    let requestUrl = await url + (params? "?" + Object.keys(params).map(function (key) {
        return (key + "=" + params[key] + "&")
    }).join(""):"")
    String.prototype.replace(",","");
    return requestUrl;
}
export async function executePostRequest(url, params,body) {
    let result = []
    let requestUrl= await requestUrlBuilder(url,params)
    await fetch(requestUrl,{
        method:POST,
        headers: {
            'Content-Type': 'application/json'
          },
        body:body
    }).then(async (response) => {
        result = await response.json();
    })
    return result;
}

export async function executeDeleteRequest(url,params){
    let result = []
    let requestUrl= await requestUrlBuilder(url,params)
    await fetch(requestUrl,{
        method:DELETE,
        headers: {
            'Content-Type': 'application/json'
          }
    }).then(async (response) => {
        result = await response.json();
    })
    return result;
}

export async function executeGetRequest(url,params){
    let result = []
    let requestUrl= await requestUrlBuilder(url,params);
    await fetch(requestUrl).then(async (response) => {
        result = await response.json();
    })
    return result;
}

