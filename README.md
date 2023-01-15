# LightPi

This is a WIP web app to controll ones lights via mqtt.
Currently the only thing u can do is to manage some light settings which aren't used yet and send an on/off state to the topic assigned to a light.

Techstack:
- .NET 7 Backend using EF7
- Blazor WASM frontend

Plannend features:
- grouping for lights (already somewhat given to the nature of mqtt topics)
- shelly rgbw2 support
- CCT lights
- RGB lights
- Pixel RGB Lights (like WS2812)