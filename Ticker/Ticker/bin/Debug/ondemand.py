from suds.client import Client
ondemand = Client('https://marketdata.websol.barchart.com/service?wsdl')

def GetQuote():
    result = client.service.getQuote('7dc15e2195a9ccc280f286b10584c9c5', 'AAPL')
    return result
