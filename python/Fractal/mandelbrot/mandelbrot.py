import math

ROOT_FIVE = math.sqrt(5)

def calculate_point(iterations: int, x: float, y: float) -> int:
    """Calculate a single point of the Mandelbrot set

    Return the number of iterations before the calculation was deemed
    to not be in the mandelbrot set, or return the value iterations
    """

    c = x+y*1j
    z = c
    i = iterations

    for s in range(iterations + 1):
        if abs(z) >= ROOT_FIVE:
            i = s
            break
        z = z*z + c
    
    return i

def calculate_area(iterations: int, bottomLeftX: float, bottomLeftY: float, topRightX: float, topRightY: float, stepX: int, stepY: int):
    """Calculate all points in the mandelbrot set for an area

    The area is defined by the top left and bottom right points, and a 
    list[list[int]] is returned that holds the number of iteratoins required
    to validate whether or not the point lies in the mandelbrot set
    """

    xStepSize = (topRightX - bottomLeftX)/stepX
    yStepSize = (bottomLeftY - topRightY)/stepY
    xPoints = [bottomLeftX + xStepSize*s for s in range(0, stepX)]
    yPoints = [bottomLeftY + yStepSize*s for s in range(0, stepY)]

    points = []

    for x in xPoints:
        row = []
        points.append(row)
        for y in yPoints:
            row.append(calculate_point(iterations, x, y))

    return points
