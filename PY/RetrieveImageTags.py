from azure.cognitiveservices.vision.computervision import ComputerVisionClient
from msrest.authentication import CognitiveServicesCredentials

subscriptionKey = "yoursubscriptionkey"
endpoint = "https://akkiaiservices.cognitiveservices.azure.com/"

computervisionClient = ComputerVisionClient(endpoint, CognitiveServicesCredentials(subscriptionKey))

imagePath = "../Images/Akki.jpg"
localImage = open(imagePath, "rb")

result = computervisionClient.tag_image_in_stream(localImage)

print("Image Tags: \n")
if len(result.tags) == 0:
    print("No tags detected.")
else:
    for tag in result.tags:
        print("'{}' with confidence {:.2f}%".format(tag.name, tag.confidence * 100))

