# Performance Report

## Benchmark before

### Debug
**Surface (500,500)**

Time: 404ms | Radius (15), Paintdrops (150)

Time: 1141ms | Radius (15), Paintdrops (300)

Time: 26210ms | Radius (500), Paintdrops (1500)


**Surface (1000,1000)**

Time: 327ms | Radius (15), Paintdrops (150)

Time: 1277ms | Radius (15), Paintdrops (300)

Time: 22635ms | Radius (500), Paintdrops (1500)


**Surface (2000,2000)**

Time: 325ms | Radius (15), Paintdrops (150)

Time: 1314ms | Radius (15), Paintdrops (300)

Time: 11911ms | Radius (500), Paintdrops (1500)

### Release

**Surface (500,500)**

Time: 253ms | Radius (15), Paintdrops (150)

Time: 646ms | Radius (15), Paintdrops (300)

Time: 16059ms | Radius (500), Paintdrops (1500)


**Surface (1000,1000)**

Time: 138ms | Radius (15), Paintdrops (150)

Time: 716ms | Radius (15), Paintdrops (300)

Time: 13335ms | Radius (500), Paintdrops (1500)


**Surface (2000,2000)**

Time: 128ms | Radius (15), Paintdrops (150)

Time: 736ms | Radius (15), Paintdrops (300)

Time: 7365ms | Radius (500), Paintdrops (1500)


## Benchmark after

### Debug

**Surface (500,500)**

Time: 238ms | Radius (15), Paintdrops (150)

Time: 292ms | Radius (15), Paintdrops (300)

Time: 3812ms | Radius (500), Paintdrops (1500)


**Surface (1000,1000)**

Time: 82ms | Radius (15), Paintdrops (150)

Time: 320ms | Radius (15), Paintdrops (300)

Time: 3281ms | Radius (500), Paintdrops (1500)


**Surface (2000,2000)**

Time: 98ms | Radius (15), Paintdrops (150)

Time: 312ms | Radius (15), Paintdrops (300)

Time: 1810ms | Radius (500), Paintdrops (1500)


### Release

Surface (500,500)

Time: 109ms | Radius (15), Paintdrops (150)

Time: 306ms | Radius (15), Paintdrops (300)

Time: 3268ms | Radius (500), Paintdrops (1500)


Surface (1000,1000)

Time: 65ms | Radius (15), Paintdrops (150)

Time: 203ms | Radius (15), Paintdrops (300)

Time: 2787ms | Radius (500), Paintdrops (1500)


Surface (2000,2000)

Time: 60ms | Radius (15), Paintdrops (150)

Time: 207ms | Radius (15), Paintdrops (300)

Time: 1243ms | Radius (500), Paintdrops (1500)


## Conclusion

So after adding parallel loops and optimizing little details in my app, the perforamnce improved significatly.  My time went from 7000ms to 1200ms. 