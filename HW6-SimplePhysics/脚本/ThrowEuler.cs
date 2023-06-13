// 实验B：模拟抛物运动
// TODO:
// 1. 参考注释补全代码，用Explicit Euler方法模拟抛物运动
// 2. 设置不同的初速度，观察运动效果
// 3. 尝试不同大小的时间步长，通过修改step的值来控制步长
// 4. 不同时间步长之间进行对比，以及与解析式方式对比
class ThrowEuler : MonoBehaviour
{
    // current position
    private float height;
    private float x;
    private float z;
    // current velocity
    private Vector3 v = new Vector3(15,0,0); // try different initial values
    private float g = 9.79f; // gravity
    private int step = 2; // You can change this!
    private int count; // used to control the frequency of updates

    // TODO: complete the function
    void UpdatePosition()
    {
        // 1. update position, move at speed of v for one time step 
		height = height - v.y * Time.deltaTime * step;
        x = x + v.x * Time.deltaTime * step;
        z = z + v.z * Time.deltaTime * step;
        // 2. calculate v in the next time step
        v.y = v.y + g * Time.deltaTime * step;
		v.x = v.x + 0 * Time.deltaTime * step;
        v.z = v.z + 0 * Time.deltaTime * step;
        // 3. check whether reach the bottom
		if (height <= transform.localScale.y/2)
        {
            v.x = 0;
            v.y = 0;
            v.z = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // set initial values
        height = transform.position.y;
        x = transform.position.x;
        z = transform.position.z;
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count >= step)
        {
            // calculate new position
            UpdatePosition();
            // set new position
            transform.position = new Vector3(x, height, z);
            count = 0;
        }
    }
}
