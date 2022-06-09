namespace Mahjong.Domain.Models;

public class Xorshift128 : Random
{
    private uint x_;
    private uint y_;
    private uint z_;
    private uint w_;

    /// <summary>
    /// GUIDを使用してXorshift128クラスのインスタンスを初期化します。
    /// </summary>
    /// <param name="guid">シードGUID</param>
    public Xorshift128(Guid guid)
    {
        var bytes = guid.ToByteArray();
        x_ = BitConverter.ToUInt32(bytes, 0);
        y_ = BitConverter.ToUInt32(bytes, 4);
        z_ = BitConverter.ToUInt32(bytes, 8);
        w_ = BitConverter.ToUInt32(bytes, 12);
    }

    /// <summary>
    /// 乱数を返します。
    /// </summary>
    /// <returns>
    /// UInt32.MinValue 以上 UInt32.MaxValue 以下の
    /// 32ビット符号なし整数。
    /// </returns>
    public uint NextUInt32()
    {
        //実際に乱数を生成している部分
        var t = x_ ^ (x_ << 11);
        x_ = y_; y_ = z_; z_ = w_;
        return (w_ = (w_ ^ (w_ >> 19)) ^ (t ^ (t >> 8)));
    }

    protected override double Sample()
    {
        //UInt32の値を、0.0以上1.0未満のDouble値に変換する
        return NextUInt32() * (1.0 / (uint.MaxValue + 1.0));
    }

    public override double NextDouble()
    {
        return Sample();
    }

    public override int Next(int maxValue)
    {
        if (maxValue < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        }
        //偏りのある方法だが、簡易的にSample()を使用して計算する
        //偏りのない方法は、Math.NET NumericsのRandomSource.csを参照
        return (int)(Sample() * maxValue);
    }

    public override int Next(int minValue, int maxValue)
    {
        return maxValue >= minValue
            ? (int)(Sample() * ((double)maxValue - minValue) + minValue)
            : throw new ArgumentOutOfRangeException(nameof(minValue));
    }

    public override int Next()
    {
        return (int)(Sample() * int.MaxValue);
    }

    public override void NextBytes(byte[] buffer)
    {
        if (buffer is null) throw new ArgumentNullException(nameof(buffer));
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (byte)(NextUInt32() % 256);
        }
    }
}